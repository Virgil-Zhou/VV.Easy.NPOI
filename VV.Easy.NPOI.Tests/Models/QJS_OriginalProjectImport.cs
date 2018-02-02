using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Easy.NPOI.Attributes;
using VV.Easy.NPOI.Models;

namespace VV.Easy.NPOI.Tests.Models
{
    [Sheet("资产信息")]
    public class QJS_OriginalProjectImport
    {
        /// <summary>
        /// 项目资产编号
        /// </summary>
        [Column("原始项目编号")]
        public string ProjectCode { get; set; }

        /// <summary>
        /// 机构号代码
        /// </summary>
        [Column("发行机构", ColumnFlags.ColRequired | ColumnFlags.NotNullOrWhiteSpace)]
        public string InstitutionNo { get; set; }

        /// <summary>
        /// 资金划款方式 (0按产品 1按机构)
        /// </summary>
        [Column("资金划款方式")]
        public int ReturnWay { get; set; }

        /// <summary>
        /// 产品代码
        /// </summary>
        [Column("产品代码")]
        public string ProductCode { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Column("产品名称")]
        public string ProjectName { get; set; }

        /// <summary>
        /// 项目资产类型 (以网金接口为准)
        /// </summary>
        [Column("产品类型")]
        public string ProjectType { get; set; }

        /// <summary>
        /// 项目提供方
        /// </summary>
        [Column("产品提供方")]
        public string ProjectProvider { get; set; }

        /// <summary>
        /// 合同ID（网金返回）
        /// </summary>
        [Column("产品合同ID")]
        public string ContractId { get; set; }

        /// <summary>
        /// 业务控制集扩展
        /// </summary>
        [Column("业务控制集扩展")]
        public string BusinessExt { get; set; }

        /// <summary>
        /// 收益计算类型 (1约定收益  2净值浮动 3分配收益)
        /// </summary>
        [Column("收益计算类型")]
        public int ProfitCalType { get; set; }

        /// <summary>
        /// 项目描述（网金返回）
        /// </summary>
        [Column("产品描述")]
        public string ProjectDescription { get; set; }

        /// <summary>
        /// 项目备注
        /// </summary>
        [Column("备注")]
        public string ProjectRemark { get; set; }

        /// <summary>
        /// 项目收益说明
        /// </summary>
        [Column("产品收益说明")]
        public string ProjectProfitRemark { get; set; }

        /// <summary>
        /// 项目风险说明
        /// </summary>
        [Column("产品风险说明")]
        public string ProjectRiskRemark { get; set; }

        /// <summary>
        /// 项目限购年龄上限(为空表示不限制)
        /// </summary>
        [Column("产品限购年龄上限")]
        public int? AgeLimitUp { get; set; }

        /// <summary>
        /// 项目限购年龄下限(为空表示不限制)
        /// </summary>
        [Column("产品限购年龄下限")]
        public int? AgeLimitDown { get; set; }

        /// <summary>
        /// 是否需要风险评测
        /// </summary>
        [Column("是否需要风险评测")]
        public bool IsNeedRisk { get; set; }

        /// <summary>
        /// 风险等级
        /// </summary>
        [Column("产品风险等级")]
        public string RiskLevel { get; set; }

        /// <summary>
        /// 融资期限
        /// </summary>
        [Column("产品期限")]
        public int Duration { get; set; }

        /// <summary>
        /// 期限单位
        /// </summary>
        [Column("期限单位")]
        public string DurationUnit { get; set; }

        /// <summary>
        /// 起息日
        /// </summary>
        [Column("起息日")]
        public DateTime? ValueDate { get; set; }

        /// <summary>
        /// 到期日
        /// </summary>
        [Column("到期日")]
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// 还款日
        /// </summary>
        [Column("还款日")]
        public DateTime RepaymentDate { get; set; }

        /// <summary>
        /// 交易确认文件生成日期
        /// </summary>
        [Column("确认日")]
        public DateTime? ConfirmDate { get; set; }

        /// <summary>
        /// 投标开始时间
        /// </summary>
        [Column("上架时间")]
        public DateTime? BidStartTime { get; set; }

        /// <summary>
        /// 收益类型（1保本保息 2保底预期 3保本预期 4非保本预期 5非保本浮动 6保本浮动买个7保底浮动收益）
        /// </summary>
        [Column("收益类型")]
        public int ProfitType { get; set; }

        /// <summary>
        /// 预期年化利率
        /// </summary>
        [Column("预期年化利率")]
        public decimal YearInterest { get; set; }

        /// <summary>
        /// 保底年化利率
        /// </summary>
        [Column("保底年化利率")]
        public decimal BaseInterest { get; set; }

        /// <summary>
        /// 项目资产规模金额（库存）
        /// </summary>
        [Column("库存")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 最低募集成功金额
        /// </summary>
        [Column("最低募集成功金额")]
        public decimal LowestAmount { get; set; }

        /// <summary>
        /// 起售金额
        /// </summary>
        [Column("起售金额")]
        public decimal MinSaleAmount { get; set; }

        /// <summary>
        /// 单位加价
        /// </summary>
        [Column("单位加价金额")]
        public decimal UnitAmount { get; set; }

        /// <summary>
        /// 佣金费率
        /// </summary>
        [Column("佣金费率")]
        public decimal CommissionRate { get; set; }

        /// <summary>
        /// 机构产品代码
        /// </summary>
        [Column("机构产品代码")]
        public string InstitutionProjectNo { get; set; }


        [Column("下架时间")]
        public DateTime? ActualBidEndTime { get; set; }

        /// <summary>
        /// 项目资产渠道 (1网金CTB)
        /// </summary>
        [Column("来源渠道")]
        public int ProjectChannel { get; set; }

        /// <summary>
        /// 结算方
        /// </summary>
        [Column("结算方")]
        public int? SettlementParty { get; set; }

        /// <summary>
        /// 结算机构号
        /// </summary>
        [Column("结算机构号")]
        public string SettlementInstitution { get; set; }

        /// <summary>
        /// 发行人类型
        /// </summary>
        [Column("发行人类型")]
        public int? Type { get; set; }

        /// <summary>
        /// 发行人名称
        /// </summary>
        [Column("发行人名称")]
        public string Name { get; set; }

        /// <summary>
        /// 发行人证件号
        /// </summary>
        [Column("发行人证件号")]
        public string IDNumber { get; set; }

        /// <summary>
        /// 发行人账户户名
        /// </summary>
        [Column("发行人账户户名")]
        public string AccountName { get; set; }

        /// <summary>
        /// 发行人账户账号
        /// </summary>
        [Column("发行人账户账号")]
        public string AccountNo { get; set; }

        /// <summary>
        /// 发行人开户行
        /// </summary>
        [Column("发行人开户行")]
        public string BankName { get; set; }

        /// <summary>
        /// 发行人开户省
        /// </summary>
        [Column("发行人开户省")]
        public string BankProvince { get; set; }

        /// <summary>
        /// 发行人开户市
        /// </summary>
        [Column("发行人开户市")]
        public string BankCity { get; set; }

        /// <summary>
        /// 发行人开户支行
        /// </summary>
        [Column("发行人开户支行")]
        public string BranchBankName { get; set; }

        /// <summary>
        /// 发行人开户支行联行号
        /// </summary>
        [Column("发行人开户支行联行号")]
        public string BranchBankCode { get; set; }

        /// <summary>
        /// 发行人账户类型
        /// </summary>
        [Column("发行人账户类型")]
        public int? AccountType { get; set; }

        /// <summary>
        /// 发行人法定代表人姓名
        /// </summary>
        [Column("发行人法定代表人姓名")]
        public string LegalRepresentativeName { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Column("身份证号")]
        public string IDCard { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Column("手机")]
        public string Mobile { get; set; }

        /// <summary>
        /// 发行人相关附件
        /// </summary>
        [Column("发行人相关附件")]
        public string IssuerAttachment { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 发行人简介
        /// </summary>
        [Column("发行人简介")]
        public string AboutIssuer { get; set; }

        /// <summary>
        /// 经营范围
        /// </summary>
        [Column("经营范围")]
        public string BusinessScope { get; set; }

        /// <summary>
        /// 资产简介
        /// </summary>
        [Column("资产简介")]
        public string AssetBriefIntroduction { get; set; }

        /// <summary>
        /// 资金用途
        /// </summary>
        [Column("资金用途")]
        public string UseOfFunds { get; set; }

        /// <summary>
        /// 还款来源
        /// </summary>
        [Column("还款来源")]
        public string SourceOfRepayment { get; set; }

        /// <summary>
        /// 增信措施
        /// </summary>
        [Column("增信措施")]
        public string CreditPromotionMeasure { get; set; }

        /// <summary>
        /// 到期回款价款（预测）
        /// </summary>
        [Column("到期回款价款（预测）")]
        public decimal? ReceivableAmount { get; set; }

        /// <summary>
        /// 发行费用合计
        /// </summary>
        [Column("发行费用合计")]
        public decimal? DistributionCostAmount { get; set; }

        /// <summary>
        /// 发行成本率
        /// </summary>
        [Column("发行成本率")]
        public decimal? DistributionCostsRate { get; set; }

        /// <summary>
        /// 适合客户
        /// </summary>
        [Column("适合客户")]
        public string ApplicablePeople { get; set; }

        /// <summary>
        /// 还款方式
        /// </summary>
        [Column("还款方式")]
        public int? RepaymentType { get; set; }

        /// <summary>
        /// 原资产期限
        /// </summary>
        [Column("原资产期限")]
        public int? AssetDuration { get; set; }

        /// <summary>
        /// 发行相关文件
        /// </summary>
        [Column("发行相关文件")]
        public string IssuanceDocument { get; set; }

        /// <summary>
        /// 认购协议模板
        /// </summary>
        [Column("认购协议模板")]
        public string ProtocolTemplate { get; set; }
    }
}
