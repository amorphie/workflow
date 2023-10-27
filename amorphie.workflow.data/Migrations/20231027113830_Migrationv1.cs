using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace amorphie.workflow.data.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageComponentUiModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageComponentUiModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Operation = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Timeout = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZeebeMessages",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Process = table.Column<string>(type: "text", nullable: false),
                    Gateway = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZeebeMessages", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "InstanceEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstanceTransitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExecutedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    InputData = table.Column<string>(type: "text", nullable: false),
                    OutputData = table.Column<string>(type: "text", nullable: false),
                    AdditionalData = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: false),
                    ZeebeFlowName = table.Column<string>(type: "text", nullable: true),
                    EntityName = table.Column<string>(type: "text", nullable: false),
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    StateName = table.Column<string>(type: "text", nullable: false),
                    BaseStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instances_ZeebeMessages_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeMessages",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "InstanceTransitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstanceId = table.Column<Guid>(type: "uuid", nullable: false),
                    FromStateName = table.Column<string>(type: "text", nullable: false),
                    ToStateName = table.Column<string>(type: "text", nullable: false),
                    EntityData = table.Column<string>(type: "text", nullable: false),
                    FormData = table.Column<string>(type: "text", nullable: true),
                    AdditionalData = table.Column<string>(type: "text", nullable: true),
                    RouteData = table.Column<string>(type: "text", nullable: true),
                    QueryData = table.Column<string>(type: "text", nullable: true),
                    TransitionName = table.Column<string>(type: "text", nullable: true),
                    FinishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstanceTransitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstanceTransitions_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageComponents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PageId = table.Column<Guid>(type: "uuid", nullable: true),
                    PageName = table.Column<string>(type: "text", nullable: true),
                    componentName = table.Column<string>(type: "text", nullable: false),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false, computedColumnSql: "to_tsvector('english', coalesce(\"type\", '') || ' ' || coalesce(\"componentName\", '') || ' ' || coalesce(\"PageName\", '') || ' ' || coalesce(\"transitionName\", ''))", stored: true),
                    transitionName = table.Column<string>(type: "text", nullable: true),
                    visibility = table.Column<bool>(type: "boolean", nullable: true),
                    type = table.Column<string>(type: "text", nullable: true),
                    uiModelId = table.Column<Guid>(type: "uuid", nullable: true),
                    parentComponentId = table.Column<Guid>(type: "uuid", nullable: true),
                    componentJson = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageComponents_PageComponentUiModels_uiModelId",
                        column: x => x.uiModelId,
                        principalTable: "PageComponentUiModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageComponents_PageComponents_parentComponentId",
                        column: x => x.parentComponentId,
                        principalTable: "PageComponents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageComponents_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: true),
                    OnEntryFlowName = table.Column<string>(type: "text", nullable: true),
                    OnExitFlowName = table.Column<string>(type: "text", nullable: true),
                    BaseStatus = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Name);
                    table.ForeignKey(
                        name: "FK_States_ZeebeMessages_OnEntryFlowName",
                        column: x => x.OnEntryFlowName,
                        principalTable: "ZeebeMessages",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_States_ZeebeMessages_OnExitFlowName",
                        column: x => x.OnExitFlowName,
                        principalTable: "ZeebeMessages",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Transitions",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    FromStateName = table.Column<string>(type: "text", nullable: false),
                    ToStateName = table.Column<string>(type: "text", nullable: true),
                    FlowName = table.Column<string>(type: "text", nullable: true),
                    PageId = table.Column<Guid>(type: "uuid", nullable: true),
                    ServiceName = table.Column<string>(type: "text", nullable: true),
                    TypeofUi = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transitions", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Transitions_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transitions_States_FromStateName",
                        column: x => x.FromStateName,
                        principalTable: "States",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transitions_States_ToStateName",
                        column: x => x.ToStateName,
                        principalTable: "States",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Transitions_ZeebeMessages_FlowName",
                        column: x => x.FlowName,
                        principalTable: "ZeebeMessages",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: false),
                    PageComponentUiModelId = table.Column<Guid>(type: "uuid", nullable: true),
                    PageId_Page = table.Column<Guid>(type: "uuid", nullable: true),
                    StateName_Description = table.Column<string>(type: "text", nullable: true),
                    StateName_Title = table.Column<string>(type: "text", nullable: true),
                    TransitionName_Form = table.Column<string>(type: "text", nullable: true),
                    TransitionName_HistoryForm = table.Column<string>(type: "text", nullable: true),
                    TransitionName_Page = table.Column<string>(type: "text", nullable: true),
                    TransitionName_Title = table.Column<string>(type: "text", nullable: true),
                    WorkflowName_HistoryForm = table.Column<string>(type: "text", nullable: true),
                    WorkflowName_Title = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translation_PageComponentUiModels_PageComponentUiModelId",
                        column: x => x.PageComponentUiModelId,
                        principalTable: "PageComponentUiModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Translation_Pages_PageId_Page",
                        column: x => x.PageId_Page,
                        principalTable: "Pages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Translation_States_StateName_Description",
                        column: x => x.StateName_Description,
                        principalTable: "States",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_States_StateName_Title",
                        column: x => x.StateName_Title,
                        principalTable: "States",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Transitions_TransitionName_Form",
                        column: x => x.TransitionName_Form,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Transitions_TransitionName_HistoryForm",
                        column: x => x.TransitionName_HistoryForm,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Transitions_TransitionName_Page",
                        column: x => x.TransitionName_Page,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Translation_Transitions_TransitionName_Title",
                        column: x => x.TransitionName_Title,
                        principalTable: "Transitions",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsStateManager = table.Column<bool>(type: "boolean", nullable: false),
                    AllowOnlyOneActiveInstance = table.Column<bool>(type: "boolean", nullable: false),
                    AvailableInStatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string[]>(type: "text[]", nullable: true),
                    ZeebeFlowName = table.Column<string>(type: "text", nullable: true),
                    WorkflowStatus = table.Column<int>(type: "integer", nullable: true),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: true, computedColumnSql: "to_tsvector('english', coalesce(\"Name\", ''))", stored: true),
                    RecordId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkflowEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByBehalfOf = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Workflows_WorkflowEntities_WorkflowEntityId",
                        column: x => x.WorkflowEntityId,
                        principalTable: "WorkflowEntities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workflows_ZeebeMessages_ZeebeFlowName",
                        column: x => x.ZeebeFlowName,
                        principalTable: "ZeebeMessages",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstanceEvents_InstanceTransitionId",
                table: "InstanceEvents",
                column: "InstanceTransitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_EntityName_RecordId_StateName",
                table: "Instances",
                columns: new[] { "EntityName", "RecordId", "StateName" });

            migrationBuilder.CreateIndex(
                name: "IX_Instances_StateName",
                table: "Instances",
                column: "StateName");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_WorkflowName",
                table: "Instances",
                column: "WorkflowName");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_ZeebeFlowName",
                table: "Instances",
                column: "ZeebeFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransitions_FromStateName",
                table: "InstanceTransitions",
                column: "FromStateName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransitions_InstanceId",
                table: "InstanceTransitions",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransitions_ToStateName",
                table: "InstanceTransitions",
                column: "ToStateName");

            migrationBuilder.CreateIndex(
                name: "IX_InstanceTransitions_TransitionName",
                table: "InstanceTransitions",
                column: "TransitionName");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_PageId",
                table: "PageComponents",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_parentComponentId",
                table: "PageComponents",
                column: "parentComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_SearchVector",
                table: "PageComponents",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_transitionName",
                table: "PageComponents",
                column: "transitionName");

            migrationBuilder.CreateIndex(
                name: "IX_PageComponents_uiModelId",
                table: "PageComponents",
                column: "uiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_States_OnEntryFlowName",
                table: "States",
                column: "OnEntryFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_States_OnExitFlowName",
                table: "States",
                column: "OnExitFlowName");

            migrationBuilder.CreateIndex(
                name: "IX_States_WorkflowName",
                table: "States",
                column: "WorkflowName");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_FlowName",
                table: "Transitions",
                column: "FlowName");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_FromStateName",
                table: "Transitions",
                column: "FromStateName");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_PageId",
                table: "Transitions",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Transitions_ToStateName",
                table: "Transitions",
                column: "ToStateName");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_PageComponentUiModelId",
                table: "Translation",
                column: "PageComponentUiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_PageId_Page",
                table: "Translation",
                column: "PageId_Page");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_StateName_Description",
                table: "Translation",
                column: "StateName_Description");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_StateName_Title",
                table: "Translation",
                column: "StateName_Title");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TransitionName_Form",
                table: "Translation",
                column: "TransitionName_Form");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TransitionName_HistoryForm",
                table: "Translation",
                column: "TransitionName_HistoryForm");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TransitionName_Page",
                table: "Translation",
                column: "TransitionName_Page");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TransitionName_Title",
                table: "Translation",
                column: "TransitionName_Title");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_WorkflowName_HistoryForm",
                table: "Translation",
                column: "WorkflowName_HistoryForm");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_WorkflowName_Title",
                table: "Translation",
                column: "WorkflowName_Title");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowEntities_WorkflowName",
                table: "WorkflowEntities",
                column: "WorkflowName");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_SearchVector",
                table: "Workflows",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_WorkflowEntityId",
                table: "Workflows",
                column: "WorkflowEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_ZeebeFlowName",
                table: "Workflows",
                column: "ZeebeFlowName");

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceEvents_InstanceTransitions_InstanceTransitionId",
                table: "InstanceEvents",
                column: "InstanceTransitionId",
                principalTable: "InstanceTransitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_States_StateName",
                table: "Instances",
                column: "StateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instances_Workflows_WorkflowName",
                table: "Instances",
                column: "WorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransitions_States_FromStateName",
                table: "InstanceTransitions",
                column: "FromStateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransitions_States_ToStateName",
                table: "InstanceTransitions",
                column: "ToStateName",
                principalTable: "States",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstanceTransitions_Transitions_TransitionName",
                table: "InstanceTransitions",
                column: "TransitionName",
                principalTable: "Transitions",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_PageComponents_Transitions_transitionName",
                table: "PageComponents",
                column: "transitionName",
                principalTable: "Transitions",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Workflows_WorkflowName",
                table: "States",
                column: "WorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Workflows_WorkflowName_HistoryForm",
                table: "Translation",
                column: "WorkflowName_HistoryForm",
                principalTable: "Workflows",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Translation_Workflows_WorkflowName_Title",
                table: "Translation",
                column: "WorkflowName_Title",
                principalTable: "Workflows",
                principalColumn: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkflowEntities_Workflows_WorkflowName",
                table: "WorkflowEntities",
                column: "WorkflowName",
                principalTable: "Workflows",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkflowEntities_Workflows_WorkflowName",
                table: "WorkflowEntities");

            migrationBuilder.DropTable(
                name: "InstanceEvents");

            migrationBuilder.DropTable(
                name: "PageComponents");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "InstanceTransitions");

            migrationBuilder.DropTable(
                name: "PageComponentUiModels");

            migrationBuilder.DropTable(
                name: "Instances");

            migrationBuilder.DropTable(
                name: "Transitions");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "WorkflowEntities");

            migrationBuilder.DropTable(
                name: "ZeebeMessages");
        }
    }
}
